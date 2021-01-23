    SelectView(0);
            Validate();
            if (IsValid)
            {
                SelectView(1);
                Validate();
                if (IsValid)
                {
                    SelectView(2);
                    Validate();
                    if (IsValid)
                    {
                        SelectView(3);
                        Validate();
                        if (IsValid)
                        {
                            UpdateHeader();
                            Response.Redirect("FinConfLanding.aspx");
                        }
                    }
                }
            }
