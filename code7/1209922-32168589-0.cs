            static void Main(string[] args)
            {
                List<List<object>> ordered = new List<List<object>>();
                int SelectedFirstCategory = 1;
                int SelectedSecondCategory = 2;
                int SelectedThirdCategory = 3;
                var groups = ordered.GroupBy(k => MyGroup(
                    k[SelectedFirstCategory],
                    k[SelectedSecondCategory],
                    k[SelectedThirdCategory])
                );
            }
            static List<object> MyGroup(object a, object b, object c)
            {
                List<object> results = new List<object>();
                if (a != null) results.Add(a);
                if (b != null) results.Add(b);
                if (c != null) results.Add(c);
                return results;
            }​
