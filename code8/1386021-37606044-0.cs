            Command getmbPerms = new Command("Get-MailboxPermission");
            getmbPerms.Parameters.Add("Identity", Mailbox);
            Pipeline plPileLine = Runspace.CreatePipeline();
            plPileLine.Commands.Add(getmbPerms);
            Collection<PSObject> RsResultsresults = plPileLine.Invoke();
            foreach (PSObject obj in RsResultsresults)
            {
                Console.WriteLine(obj.Properties["User"].Value.ToString());
                PSObject AccessRights = (PSObject)obj.Properties["AccessRights"].Value;
                System.Collections.ArrayList AccessRightsCol = (System.Collections.ArrayList)AccessRights.BaseObject;
                foreach (String Permission in AccessRightsCol)
                {
                    Console.WriteLine(Permission);
                }
                
            }
            plPileLine.Stop();
