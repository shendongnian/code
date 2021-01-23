    public static class GameObjectExtensions {
        public static void ObjectLoop<T>(this GameObject value, int uBound, IList<T> list, T item) where T : UnityEngine.Component {
            for (int x = 0; x < uBound; x++) {
                list.Add(GameObject.Instantiate(item) as T);
                list[x].transform.SetParent(value.transform);
                list[x].gameObject.SetActive(false);
            }
        }
    }
