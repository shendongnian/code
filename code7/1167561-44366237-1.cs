    public class ValuesController : ApiController
    {
        public void Put(int id, [FromBody]Item value)
        {
            if (value.NameSpecified)
            {
            }
            else
            {
            }
        }
    }
    public class Item
    {
        internal bool NameSpecified = false;
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NameSpecified = true;
            }
        }
    }
