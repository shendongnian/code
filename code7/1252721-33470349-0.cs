    protected void btnGetImages_Click(object sender, EventArgs e)
            {
                Assembly currentAssembly = Assembly.GetExecutingAssembly();
                string[] resources = currentAssembly.GetManifestResourceNames();
                foreach(string resource in resources)
                {
                    Response.Write(resource + "<br/>");
                }
            }
