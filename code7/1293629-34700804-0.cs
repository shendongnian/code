       public class ValidKey: Tuple<VNodeClassID, VNodeClassID>
        {
            public ValidKey(VNodeClassID a, VNodeClassID b) : base(a, b) { }
        }
    
    
            static Dictionary<ValidKey, bool> validation = new Dictionary<ValidKey, bool>() {
                { new ValidKey(VNodeClassID.Apple, VNodeClassID.Watermellon), true },
                { new ValidKey(VNodeClassID.Apple, VNodeClassID.Orange), true },
                { new ValidKey(VNodeClassID.Orange, VNodeClassID.Grape), true }
            };
            bool Validate(VNodeClassID thing1, VNodeClassID thing2)
            {
                var key = new ValidKey(thing1, thing2);
                return validation.ContainsKey(key) ? validation[key] : false;
            }
