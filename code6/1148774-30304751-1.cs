        private static string CalculateStringOrder(Page p)
        {
            var path = PathToTopRec(p);
            var builder=new StringBuilder();
            foreach (var p in path)
            {
                builder.AppendFormat("{0:0000}.",p.ItemOrder);
            }
            builder.Remove(builder.Length- 1, 1);
            return builder.ToString();
        }
