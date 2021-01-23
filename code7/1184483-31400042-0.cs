    public static bool FindPage<T>(object modelId, IEnumerable<T> entities, int pageSize, int calculatedPage, int? id)
        {
            if (modelId != null) {
                calculatedPage = 0;
                IEnumerable<IEnumerable<T>> pp = entities.Partition(pageSize);
                int page = 0;
                bool found = false;
                foreach (var item in pp) {
                    page++;
                    IEnumerable<T> inner = item as IEnumerable<T>;
                    foreach (var product in inner) {
                        if (id == (int)modelId) {
                            found = true;
                            break;
                        }
                    }
                    if (found)
                        break;
                }
                if (found)
                    calculatedPage = page;
                else
                    calculatedPage = 0;
                return found;
            }
            return false;
        }
