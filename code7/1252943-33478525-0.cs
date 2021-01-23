    bool Flag = true;
     browser.DocumentCompleted += (o, a) =>
            {
                //MessageBox.Show("In DocumentCompleted.");
                List<Status> statusy = new List<Status>();
                IHTMLDocument2 currentDoc = (IHTMLDocument2)browser.Document.DomDocument;
                //parsing the html doc
                string Statuses = "";
                foreach (Status status in statusy)
                {
                    Statuses += String.Format("{0} {1} - {2} --> {3}{4}", status.Date, status.Time, status.Centre, status.Message, Environment.NewLine);
                }
                MessageBox.Show(Statuses);   
                Flag = false;
            };
    while (Flag) { }
         
