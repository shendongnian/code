       private async void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var c = new ClassFromMyLibrary1();
                var v1 = await c.MethodFromMyLibrary1("test1");
                var v2 = await ActionToProcessNewValue(v1);
                var v3 = c.TransformProcessedValue(v2);
                Label2.Content = v3;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError("{0}", ex);
                throw;
            }
        }
        private Task<string> ActionToProcessNewValue(string s)
        {
            Label1.Content = s;
            return Task.FromResult(string.Format("test2{0}", s));
        }
