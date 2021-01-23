      private void myForm_Load(object sender, EventArgs e)
        {
             try
            {
                XDocument xdoc = new XDocument();
                xdoc = XDocument.Load("//txt.xml");
                List<XElement> listXele = new List<XElement>();
                List<userClass> clsList = new List<userClass>();
                foreach (var val in listXele)
                {
                    userClass obj = new userClass();
                    obj.City = val.Element("City").Value;
                    
                    // Check if the combo box doesn't already have the city name
                    // assuming you are populating the combo box with strings only
                    // Check for null/empty string 
                    if(!string.IsNullOrEmpty(obj.City ?? string.Empty))
                    {
                         if(!cmbBox.Items.Contains(obj.City))
                             cmbBox.Items.Add(obj.City);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
