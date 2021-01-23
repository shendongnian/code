    public class Carrier
    {
        public List<Carrier> Descendants { get; set; }
        public List<Carrier> Children { get; set; }
        public static IEnumerable<Carrier> TraverseDescendants(IEnumerable<Carrier> allCarriers, Carrier rootCarrier)
        {
            Queue<Carrier> queue = new Queue<Carrier>();
            var children = allCarriers.Where(c => c.ParentCarrierId == rootCarrier.CarrierId);
            foreach (Carrier c in children)
                queue.Enqueue(c);
            while (queue.Count > 0)
            {
                Carrier child = queue.Dequeue();
                yield return child;
                var grandchildren = allCarriers.Where(c => c.ParentCarrierId == child.CarrierId);
                foreach (Carrier c in grandchildren)
                    queue.Enqueue(c);
            }
        }
    }
