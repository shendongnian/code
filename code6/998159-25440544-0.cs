            if (chkActivate.SelectedItem.Text == "Deactivate Reminders")
            {
                chkDaysOfWeek.Enabled = false;
                chkEmailOption.Enabled = false;
                command = @"/Change /TN ""Action Item Reminder"" /Disable";
            }
            else
            {
                chkDaysOfWeek.Enabled = true;
                chkEmailOption.Enabled = true;
                command = @"/Change /TN ""Action Item Reminder"" /Enable";
            }
            if (chkEmailOption.SelectedItem.Text == "Original")
            {
                strquery = "UPDATE EmailOption set [Value] = 'true' where [Option] = 'Original Due Date'; UPDATE EmailOption set [Value] = 'false' where [Option] = 'ECD'";
                SqlCommand cmd = new SqlCommand(strquery, mycon);
                cmd.ExecuteNonQuery();
            }
            else if (chkEmailOption.SelectedItem.Text == "ECD")
            {
                strquery = "UPDATE EmailOption set [Value] = 'true' where [Option] = 'ECD'; UPDATE EmailOption set [Value] = 'false' where [Option] = 'Original Due Date'";
                SqlCommand cmd = new SqlCommand(strquery, mycon);
                cmd.ExecuteNonQuery();
            }
            List<string> days = new List<string>();
            for (int idx = 0; idx < chkDaysOfWeek.Items.Count; idx++)
            {
                if (chkDaysOfWeek.Items[idx].Selected == true)
                {
                    strquery = "UPDATE EmailOption set [Value] = 'true' where [Option] = '" + chkDaysOfWeek.Items[idx].Text.ToString() + "'";
                    days.Add(chkDaysOfWeek.Items[idx].Text.Substring(0, 3).ToUpper());
                }
                else
                    strquery = "UPDATE EmailOption set [Value] = 'false' where [Option] = '" + chkDaysOfWeek.Items[idx].Text.ToString() + "'";
                SqlCommand cmd = new SqlCommand(strquery, mycon);
                cmd.ExecuteNonQuery();
            }
            string create = @"/CREATE /SC WEEKLY /D " + string.Join(",", days) + @" /TN ""Action Item Reminder"" /TR ""C:\ActionAIM_Source\bin\ActionItemReminder.exe"" /ST 00:01 /f";
            ProcessStartInfo processInfo = new ProcessStartInfo("schtasks.exe");
         
            try
            {
                processInfo.Arguments = create;
                var process = Process.Start(processInfo);
                process.WaitForExit(1000);
                processInfo.Arguments = command;
                process = Process.Start(processInfo);
                process.WaitForExit(1000);
            }
           catch (Win32Exception ex)
           {
                Response.Write(ex.ToString());   
           }
