        public static Key ToKey(this long id)
        {
            return new Key()
            {
                Path = new KeyPathElement[]
                {
                    new KeyPathElement() { Kind = "Book", Id = (id == 0 ? (long?)null : id) }
                }
            };
        }
