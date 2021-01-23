    protected void LbSave_OnClick(object sender, EventArgs e)
        {
            foreach (RepeaterItem riTrig in RpTriggerEmails.Items)
            {
                HiddenField hfTrig = riTrig.FindControl("HfTriggerEmailId") as HiddenField;
                if (hfTrig != null)
                {
                    foreach (RepeaterItem riAtt in ((Repeater) riTrig.FindControl("RpAttendees")).Items)
                    {
                        CheckBox cb = riAtt.FindControl("CbAttendee") as CheckBox;
                        HiddenField hf = riAtt.FindControl("HfAttendeeId") as HiddenField;
                        if (cb != null && cb.Checked &&
                            hf != null && !hf.Value.IsNullOrEmpty())
                            checkboxes.Add(new GenericPair<int, int>(int.Parse(hf.Value),
                                int.Parse(hfTrig.Value)));
                    }
                }
            }
            Controller.SendTriggers(checkboxes);
        }
