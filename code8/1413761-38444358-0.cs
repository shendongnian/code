            // Iterate and assign null
            for (var i = 0; i < second_list.Count(); i++)
            {
                if (second_list[i] == "K")
                {
                    first_list[i] = null;
                }
            }
            // Iterate and assign null
            for (var i = 0; i < second_list.Count; i++)
            {
                if (second_list[i] == "Z")
                {
                    first_list[i] = null;
                }
            }
            // remove nulls without linq or lambda
            first_list.RemoveAll(delegate (string o) { return o == null; });
