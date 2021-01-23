            public bool Is(Type type)
            {
                return this.Is(new Type[]{type});
            }
            public bool Is(Type[] types)
            {
                bool isType = true;
                foreach (var type in types)
                {
                    isType &= this._rolles.Any(r => r.GetType() == type);
                }
                return isType;
            }
