        private void btnDetails_Click(object sender, EventArgs e)
        {
            //Get name of selected item from combobox
            string eventName;
            //Traverse array to determine the match
            MethodAfterRefactor(() => 
            {
                //Display details
                lblDetails.Text = t.getDetails();
                //Display image
                displayImage(t.getFileName());
            });
        }
        private void MethodAfterRefactor(Func<object> p)
        {
            foreach (Ticket t in events)
            {
                if (t.getName().Equals(cbEvents.SelectedItem.ToString()))
                {
                    p.Invoke();
                }
            }
        }
