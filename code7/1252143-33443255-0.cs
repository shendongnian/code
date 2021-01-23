    using System.Linq;
    using System.Threading;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class _Default : System.Web.UI.Page
    {
        private List<object> objects = new List<object>();
    
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10000000; i++)
            {
                objects.Add(new byte[64]);
            }
    
            double averageDuration = 0;
            for (int x = 0; x < 100; x++)
            {
                objects.Add(new byte[64]);
                Stopwatch sw = Stopwatch.StartNew();
                GC.GetTotalMemory(false);
                sw.Stop();
                averageDuration += sw.Elapsed.TotalMilliseconds;
            }
    
            Response.Write("Acerage Duration: " + averageDuration);
        }
    }
