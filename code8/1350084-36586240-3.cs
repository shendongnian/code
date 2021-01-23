    [ParseChildren(true)]
    [PersistChildren(false)]
    public class EmployeesViewer : Control
    {
        private readonly List<Person> _employees = new List<Person>();
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<Person> Employees
        {
            get { return _employees; }
        }
        protected override void Render(HtmlTextWriter writer)
        {
            foreach (Person person in this.Employees)
            {
                writer.RenderBeginTag(HtmlTextWriterTag.P);
                writer.WriteEncodedText(string.Format("{0} {1}", person.GivenName, person.FamilyName));
                writer.RenderEndTag();
            }
        }
    }
