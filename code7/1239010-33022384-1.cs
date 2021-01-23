     public List<Form> SampleForms = new List<Form>();
        private void CreateForm()
        {
           var form = new Form();
           SampleForms.Add(form);
           ...
        }
    //use this to get a form from the collection. Form.ID, Form.Text
    private Form GetForm(string formName)
    {
       return SampleForms.FirstOrDefault(f => f.ID.Equals(formName));
    }
