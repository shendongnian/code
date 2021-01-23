    try
            {
                //String test1 = test.Value;
                List<string> listParticipantName = new List<string>();
                if (ViewState["numberofparticipants"] != null)
                {
                    int numberofparticipants = Convert.ToInt32(ViewState["numberofparticipants"]);
                    for (int i = 0; i < numberofparticipants; i++)
                    {
                        string findcontrol = "txtNameofParticipant" + i;
                        var txtParticipantName = panelNameofParticipants.FindControl(string.Format("txtNameofParticipant{0}", i)) as TextBox;
                        listParticipantName.Add(txtParticipantName.Text);
                    }
                }
                foreach (var item in listParticipantName)
                {
                    Response.Write(string.Format("{0}<br/>", item));
                }
            }
            catch (Exception ex)
            {
            }
