    public interface EOPHasProject { int ProjectId { get; } }
    public class EOPKeuzelijst<TEntity> : EOPHasProject
        : EntityOverviewPage<TEntity> where TEntity : EntityBase,
        IRR_ProjectId_N,
        IRR_ObjectTypeId_N
    {
        public Int32? ProjectId { get; set; }
        public Int32? ObjectTypeId { get; set; }
    
        // No more info needed..
    }
    public partial class Keuzelijsten_Template : System.Web.UI.MasterPage
    {
        private EOPHasProject page;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.page = (EOPHasProject)this.Page;
            this.page.ProjectId // will work
    
            Response.Write(this.Page.Title);
        }
    }
