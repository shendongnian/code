    public static class ModalHelper
        {
            public static List<double> GetModals(List<List<double>> source)
            {
                return source.Select(list => list.Sum()/list.Count).ToList();
            }
        }
