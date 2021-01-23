            private string postalCode = "";
            public string PostalCode
            {
                get{return postalCode.Substring(0,2) + "-" + PostalCode.Substring(2);}
                set { postalCode = value.Replace("-",""); }
            }
