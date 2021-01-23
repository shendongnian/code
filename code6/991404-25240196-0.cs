    if (!String.IsNullOrEmpty(this.txtEOIDate.Text))
            {
                var dt = DateTime.Parse(this.txtEOIDate.Text);
                invProject.created = dt;
            }
