    public class PromotionFactory : IPromotionFactory
    {
        public IEnumerable<IPromotion> Parse(string file)
        {
            if (string.IsNullOrEmpty(file)) throw new ArgumentException(nameof(file));
            var result = new List<IPromotion>();
            foreach (var line in ReadFile(file))
            {
                var promotion = ParseLine(line);
                result.Add(promotion);
            }
            return result;
        }
        private IPromotion ParseLine(string line)
        {
            var segments = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            if (segments.Length == 0) throw new ArgumentException("Could not read segments");
            var id = int.Parse(segments[0]);
            var name = segments[1];
            var price = decimal.Parse(segments[2]);
            DateTime? date = null;
            if (segments.Length > 3)
            {
                date = new DateTime(int.Parse(segments[3]), int.Parse(segments[5]), int.Parse(segments[4]));
            }
            return new Promotion(id, name, price, date);
        }
        private IEnumerable<string> ReadFile(string file)
        {
            string line;
            using (var reader = File.OpenText(file))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        yield return line;
                    }
                }
            }
        }
    }
