            var values = new List<string>();
            for (int i = 0; i < ddlVoucherTypes.Items.Count; i++)
            {
                values.Add(ddlVoucherTypes.Items[i].Value);
            }
            var result = string.Join(",", values);
