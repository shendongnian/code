        //your process code
                SB.Append("<br/>");
            }
            // All finished!
            UpdateProgress(100, "All Database BackUp Completed!");
        }
        catch (Exception ex)
        {
            UpdateProgress(0, "Exception: " + ex.Message);
            SB.Append("Back Up Failed!");
            SB.Append("<br/>");
            SB.Append("Failed DataBase: " + DBName);
            SB.Append("<br/>");
            SB.Append("Exception: " + ex.Message);
        }
    }
    protected void UpdateProgress(double PercentComplete, string Message)
    {
        // Write out the parent script callback.
        Response.Write(String.Format("<script type=\"text/javascript\">parent.UpdateProgress({0}, '{1}');</script>", PercentComplete, Message));
        // To be sure the response isn't buffered on the server.    
        Response.Flush();
    }
     }
