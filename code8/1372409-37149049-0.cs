     StringBuilder msg =  new StringBuilder();
     msg.Append(Environment.NewLine);
     msg.Append(Environment.NewLine);
     msg.Append(Environment.NewLine);
     msg.Append("Issue ID: ");
     msg.Append(Session["IssueID"].ToString());
     msg.Append(Environment.NewLine);
     msg.Append("Issue Name: ");
     msg.Append(Session["IssueName"].ToString());
     msg.Append(Environment.NewLine);
     msg.Append(Environment.NewLine);
     msg.Append("Please do not reply to this message. Replies to this message are routed to an unmonitored mailbox. If you have questions or comments, please contact ");
     msg.Append(Session["UserFullName"].ToString());
     msg.Append(" at \"");
     msg.Append(Session["UserEmailAddress"].ToString());
     msg.Append("CONFIDENTIALITY NOTICE: This communication with its contents may contain confidential and/or legally privileged information. It is solely for the use of the intended recipient(s). Unauthorized interception, review, use, forwarding or disclosure is prohibited and may violate applicable laws including the Electronic Communications Privacy Act. If you are not the intended recipient, please contact the sender and destroy all copies of the communication.");
     Mailmessage.Value = msg.ToString();  
                    
