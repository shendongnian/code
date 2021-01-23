        void ddCarNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            Service1SoapClient client = new Service1SoapClient();
            UserDetails details = new UserDetails();
            details.userName = "Weber";
            details.password = "!Q2w#4r";
            DataTable dt = client.GetCars(details);
            foreach (DataRow row in dt.Rows)
            {
                if (ddCarNumber.SelectedValue == Convert.ToString(row[0]))
                {
                    txtCarBrand.Text = row[1].ToString();
                }
            }
        }
