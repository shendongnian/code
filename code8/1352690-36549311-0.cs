    class AuthButton : Button
        {
            public AuthButton()
            {
                var principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                this.Visible = principal.IsInRole("License_Users");
            }
        }
