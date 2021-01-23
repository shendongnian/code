    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ControlIDs != null)
            {
                foreach (string controlID in ControlIDs)
                {
                    AddChildControl(controlID);
                }
            }
        }
        protected void btnAddControl_OnClick(object sender, EventArgs e)
        {
            var rand = new Random();
            var controlID = string.Format("TestChildControl_{0}", rand.Next());
            AddChildControl(controlID);
        }
        protected void AddChildControl(string controlID)
        {
            TestChildControl childControl = (TestChildControl)LoadControl("~/TestChildControl.ascx");
            childControl.ID = controlID;
            phControlContainer.Controls.Add(childControl);
            childControl.RemoveControlButton.Click += btnRemoveControl_OnClick;
            AsyncPostBackTrigger updateTrigger = new AsyncPostBackTrigger() { ControlID = childControl.RemoveControlButton.UniqueID, EventName = "click" };
            updTest.Triggers.Add(updateTrigger);
            SaveControlIDs();
        }
        private void SaveControlIDs()
        {
            ControlIDs = phControlContainer.Controls.Cast<Control>().Select(c => c.ID).ToList();
        }
        protected void btnRemoveControl_OnClick(object sender, EventArgs e)
        {
            var removeButton = sender as Button;
            if (removeButton == null)
            {
                return;
            }
            var controlID = removeButton.CommandArgument;
            var parentControl =
                phControlContainer.Controls.Cast<TestChildControl>().FirstOrDefault(c => c.ID.Equals(controlID));
            if (parentControl != null)
            {
                phControlContainer.Controls.Remove(parentControl);
            }
            SaveControlIDs();
        }
        protected IEnumerable<string> ControlIDs
        {
            get
            {
                var ids = ViewState["ControlIDs"] ?? new List<string>();
                return (IEnumerable<string>) ids;
            }
            set { ViewState["ControlIDs"] = value; }
        } 
    }
