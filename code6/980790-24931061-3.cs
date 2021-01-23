    public static class EventHelper
    {
        /// <summary>
        /// Return true if all the atomic delegates in the multicast delegate handler are bound into the
        /// publisher, grouped together and in the same order.
        /// </summary>
        /// <param name="publisher"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static bool HasBound(this Delegate publisher, Delegate handler)
        {
            if (publisher == null || handler == null)
                return false;
            if (publisher == handler)
                return true;
            var publisherList = publisher.GetInvocationList();
            var handlerList = handler.GetInvocationList();
            return (publisherList.SublistIndex(handlerList, 0) >= 0);
        }
        public static bool HasBound<TEventArgs>(this EventHandler<TEventArgs> publisher, EventHandler<TEventArgs> handler) where TEventArgs : EventArgs
        {
            return HasBound((Delegate)publisher, (Delegate)handler);
        }
        public static bool HasBound(this EventHandler publisher, EventHandler handler)
        {
            return HasBound((Delegate)publisher, (Delegate)handler);
        }
    }
    public static class ListHelper
    {
        public static int SublistIndex<T>(this IList<T> list, IList<T> sublist, int start)
        {
            for (int listIndex = start, end = list.Count - sublist.Count + 1; listIndex < end; listIndex++)
            {
                int count = 0;
                while (count < sublist.Count && sublist[count].Equals(list[listIndex + count]))
                    count++;
                if (count == sublist.Count)
                    return listIndex;
            }
            return -1;
        }
    }
