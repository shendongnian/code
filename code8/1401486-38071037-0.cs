       <script id="clientTemplate" type="text/x-kendo-template">
              @(Html.Kendo().Grid(Model.CustomerBio).Name("CustomerDisplay#=CustomerId#"").Columns(a =>
                        {
                            a.Bound(s => s.KinName);
                             a.Bound(s => s.KinIdNumber);
                              a.Bound(s => s.KinPostalCode);
                               a.Bound(s => s.KinCity);
                        }).DataSource(a => a.Ajax().Model(b => b.Id(x => x.ProfileId)).Read("GetCustomerBioByCustomerId", "Customer",new {CustomerId="#=CustomerId#"})).Events(a => a.DataBound("onDetailsDatabound").Edit("onCustomerInfoDisplay")).ToClientTemplate())
            </script>
