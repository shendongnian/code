    public interface IEOPHasProject { int ProjectId { get; } }
    public class EOPKeuzelijst<TEntity>
        : EntityOverviewPage<TEntity> where TEntity : EntityBase,
        IRR_ProjectId_N,
        IRR_ObjectTypeId_N,
        IEOPHasProject
    {
        public Int32? ProjectId { get; set; }
        public Int32? ObjectTypeId { get; set; }
    
        // No more info needed..
    }
    public partial class Keuzelijsten_Template : System.Web.UI.MasterPage
    {
        private IEOPHasProject page;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.page = (IEOPHasProject)this.Page;
            this.page.ProjectId // will work
    
            Response.Write(this.Page.Title);
        }
    }
