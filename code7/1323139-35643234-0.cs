    public async Task<tokenclass> Process(Button Context){
                var x = await Task.Run(() =>
                {
                    tokenclass tc = new tokenclass();
                    var method = Context.Parent.GetType().GetMethod("typeHint");
                    if (method == null)
                    {
                        tc.token = null;
                        tc.hasTypeHing = false;
                        tc.result = false;                   
                    }
                    return tc;
                });
                return x;
       public class tokenclass
        {
            public string token { get; set; }
            public bool hasTypeHing { get; set; }
            public bool result { get; set; }
        }
