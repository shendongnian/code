    public partial class Cumle : UserControl
    {
       public event Action<bool> ConditionChanged = delegate {};
       private bool cond=false;
       //Some Code....
       private void timer2_Tick(object sender, EventArgs e)
       {
           //Some Code....
           if(//some condition...)
           {
               cond=true;
               ConditionChanged(cond);
           }
       }
    }
