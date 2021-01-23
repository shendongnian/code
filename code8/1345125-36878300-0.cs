    private void btnLogin_Click(object sender, EventArgs ev)
        {
            //
            //If background worker busy, show snackbar and login after
            //
            if (!bgw.IsBusy)
            {
                pnlSnackBar.Visible = true;
                lblMessage.Text = "Logging In...Please wait";
                SnackBarTimer();
                bgw.RunWorkerAsync();
            }            
        }
