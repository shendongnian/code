    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    
    namespace ExcelUpload
    {
        public partial class TestRepeater : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                CreateUserExperienceTable(LoadData());
            }
    
            private List<UserExperience> LoadData()
            {
                List<UserExperience> experiences = new List<UserExperience>();
    
                for (int i = 0; i < 5; i++)
                {
                    UserExperience newExp = new UserExperience();
                    newExp.Company = "Company " + i;
                    newExp.Role = "Role " + i;
                    newExp.CompanyDescription = "CompanyDescription " + i;
                    newExp.PeriodFrom = DateTime.Now.AddDays(i);
                    newExp.PeriodTo = DateTime.Now.AddDays(i + 5);
    
                    for (int j = 0; j < 2; j++)
                    {
                        ExperienceDuties newDuty = new ExperienceDuties();
                        newDuty.Description = "Duty Description " + j;
                        newExp.Duties.Add(newDuty);
                    }
    
                    experiences.Add(newExp);
                }
    
                return experiences;
            }
    
            private void CreateUserExperienceTable(List<UserExperience> experiences)
            {
                foreach (UserExperience experience in experiences)
                {
                    HtmlGenericControl Header = new HtmlGenericControl("h3");
                    Header.InnerHtml = experience.Company;
                    dvUserExperience.Controls.Add(Header);
    
                    Table experienceTable = new Table();
    
                    TableRow experienceRoleRow = new TableRow();
                    TableRow experienceDescriptionRow = new TableRow();
                    TableRow experiencePeriodFromRow = new TableRow();
                    TableRow experiencePeriodToRow = new TableRow();
    
                    TableCell experienceRoleTitleCell = new TableCell();
                    TableCell experienceRoleValueCell = new TableCell();
                    TableCell experienceDescriptionTitleCell = new TableCell();
                    TableCell experienceDescriptionValueCell = new TableCell();
                    TableCell experiencePeriodFromTitleCell = new TableCell();
                    TableCell experiencePeriodFromValueCell = new TableCell();
                    TableCell experiencePeriodToTitleCell = new TableCell();
                    TableCell experiencePeriodToValueCell = new TableCell();
    
                    experienceRoleTitleCell.Text = "Role:";
                    experienceRoleValueCell.Text = experience.Role;
                    experienceDescriptionTitleCell.Text = "Description:";
                    experienceDescriptionValueCell.Text = experience.CompanyDescription;
                    experiencePeriodFromTitleCell.Text = "Period From: ";
                    experiencePeriodFromValueCell.Text = experience.PeriodFrom.ToString("yy-mm-dd");
                    experiencePeriodToTitleCell.Text = "Period To:";
                    experiencePeriodToValueCell.Text = experience.PeriodTo == null
                        ? "Present"
                        : experience.PeriodTo.ToString();
    
                    experienceRoleRow.Cells.Add(experienceRoleTitleCell);
                    experienceRoleRow.Cells.Add(experienceRoleValueCell);
                    experienceDescriptionRow.Cells.Add(experienceDescriptionTitleCell);
                    experienceDescriptionRow.Cells.Add(experienceDescriptionValueCell);
                    experiencePeriodFromRow.Cells.Add(experiencePeriodFromTitleCell);
                    experiencePeriodFromRow.Cells.Add(experiencePeriodFromValueCell);
                    experiencePeriodToRow.Cells.Add(experiencePeriodToTitleCell);
                    experiencePeriodToRow.Cells.Add(experiencePeriodToValueCell);
    
                    experienceTable.Rows.Add(experienceRoleRow);
                    experienceTable.Rows.Add(experienceDescriptionRow);
                    experienceTable.Rows.Add(experiencePeriodFromRow);
                    experienceTable.Rows.Add(experiencePeriodToRow);
    
                    dvUserExperience.Controls.Add(experienceTable);
    
                    updatePageWithDuties(experience.Duties);
                }
            }
    
            private void updatePageWithDuties(List<ExperienceDuties> list)
            {
                Repeater rptDuties = new Repeater();
                rptDuties.ID = "rptDuties";
                rptDuties.DataSource = list;
                rptDuties.DataBind();
    
                foreach (RepeaterItem rptItem in rptDuties.Items)
                {
                    if (rptItem.ItemIndex == 0)
                    {
                        RepeaterItem headerTemplate = new RepeaterItem(rptItem.ItemIndex, ListItemType.Header);
                        HtmlGenericControl h4Tag = new HtmlGenericControl("h4");
                        h4Tag.InnerHtml = "Duties";
                        rptItem.Controls.Add(h4Tag);
                    }
    
                    RepeaterItem itemTemplate = new RepeaterItem(rptItem.ItemIndex, ListItemType.Item);
                    Label dutyLabel = new Label();
                    ExperienceDuties expDuties = ((IList<ExperienceDuties>)rptDuties.DataSource)[rptItem.ItemIndex];
                    dutyLabel.Text = expDuties.Description;
                    rptItem.Controls.Add(dutyLabel);
    
                    RepeaterItem seperatorItem = new RepeaterItem(rptItem.ItemIndex, ListItemType.Separator);
                    LiteralControl ltrHR = new LiteralControl();
                    ltrHR.Text = "<hr />";
                    rptItem.Controls.Add(ltrHR);
                }
    
                dvUserExperience.Controls.Add(rptDuties);
            }
        }
    
        public class UserExperience {
            public List<ExperienceDuties> Duties = new List<ExperienceDuties>();
            public string  Company { get; set; }
            public string Role { get; set; }
            public string CompanyDescription { get; set; }
            public DateTime PeriodFrom { get; set; }
            public DateTime PeriodTo { get; set; }
        }
    
        public class ExperienceDuties {
            public string Description { get; set; }
        }
    }
