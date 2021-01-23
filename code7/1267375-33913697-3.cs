        public List<CariHesapEkstre> ConvertToDesiredType ( object list )
        {
            return ( (IEnumerable<dynamic>)list ).Select(item => new CariHesapEkstre
            {
                MutabakatDetayId = item.MutabakatDetayId,
                MutabakatVar = item.MutabakatVar,
                ...
            }).ToList();
        }
