    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.HtmlControls;
    
    public partial class RepeaterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                readForm();
            }else {
                var step1 = new StepItem();
                step1.SubSteps= new List<SubStepItem>();
                step1.SubSteps.Add(new SubStepItem());
              
                var Steps = new List<StepItem>();
                Steps.Add(step1);
    
                StoredList = Steps;
    
                bindRepeater();
            }
        }
    
        private void bindRepeater()
        {
            StepRep.DataSource = StoredList;
            StepRep.DataBind();
        }
    
        private List<StepItem> StoredList
        {
            get
            {
                var o = ViewState["StoredList"];
                if (o == null) return new List<StepItem>();
                return (List<StepItem>)o;
            }
            set
            {
                ViewState["StoredList"] = value;
            }
        }
    
        private void readForm()
        {
            var steps = new List<StepItem>();
            foreach (RepeaterItem RI in StepRep.Items)
            {
                var step = new StepItem();
                step.Name = ((TextBox)RI.FindControl("NameBox")).Text;
                step.Ratio = Double.Parse(((TextBox)RI.FindControl("RatioBox")).Text);
                step.SubSteps = new List<SubStepItem>(); 
    
                var SubRep= (Repeater)RI.FindControl("SubStepRep");
                foreach (RepeaterItem SubRI in SubRep.Items)
                {
                    var subStep = new SubStepItem();
                    subStep.Name = ((TextBox)SubRI.FindControl("SubNameBox")).Text;
                    subStep.Ratio = Double.Parse(((TextBox)SubRI.FindControl("SubRatioBox")).Text);
                    step.SubSteps.Add(subStep);
                }
                steps.Add(step);
            }
            StoredList = steps;
        }
    
        protected void StepRep_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var Step = (StepItem)e.Item.DataItem;
    
                Repeater SubRep = (Repeater)e.Item.FindControl("SubStepRep");
                SubRep.DataSource = Step.SubSteps;
                SubRep.DataBind();
            }
        }
        protected void SubStepRep_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var StepRepItem = (RepeaterItem)e.Item.NamingContainer.NamingContainer;
                var tr = (HtmlTableRow)e.Item.FindControl("SubTr");
                tr.Attributes.Add("class",  "Step" + (StepRepItem .ItemIndex % 2 ) );
            }
        }
    
        protected void StepRep_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            var steps = StoredList;
            if(e.CommandName =="StepAdd") {
                steps.Add(new StepItem() ) ;
                StoredList = steps;
                bindRepeater();
            }
            else if (e.CommandName == "StepRemove")
            {
                steps.RemoveAt(e.Item.ItemIndex);
                StoredList = steps;
                bindRepeater();
            }
            else if (e.CommandName == "SubStepAdd")
            {
                steps[e.Item.ItemIndex].SubSteps.Add(new SubStepItem());
                StoredList = steps;
                bindRepeater();
            }
            
        }
    
        protected void SubStepRep_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            var StepRepItem = (RepeaterItem)e.Item.NamingContainer.NamingContainer ;  
    
            var steps = StoredList;
    
            if (e.CommandName == "SubStepRemove")
            {
                steps[StepRepItem.ItemIndex].SubSteps.RemoveAt(e.Item.ItemIndex);
    
                StoredList = steps;
                bindRepeater();
            }
        }
    
    }
    
    [Serializable]
    public class StepItem
    {
        public string Name { get; set; }
        public double Ratio { get; set; }
        public List<SubStepItem> SubSteps { get; set; }
    }
    
    [Serializable]
    public class SubStepItem
    {
        public string Name { get; set; }
        public double Ratio { get; set; }
    }
