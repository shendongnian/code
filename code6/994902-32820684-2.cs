    /// <summary>
    /// This extension method returns all available items in the IReceivableSourceBlock
    /// or an empty sequence if nothing is available. The functin does not wait.
    /// </summary>
    /// <typeparam name="T">The type of items stored in the IReceivableSourceBlock</typeparam>
    /// <param name="buffer">the source where the items should be extracted from </param>
    /// <returns>The IList with the received items. Empty if no items were available</returns>
    public static IList<T> TryReceiveAllEx<T>(this IReceivableSourceBlock<T> buffer)
    {
        /* Microsoft TPL Dataflow version 4.5.24 contains a bug in TryReceiveAll
         * Hence this function uses TryReceive until nothing is available anymore
         * */
        IList<T> receivedItems = new List<T>();
        T receivedItem = default(T);
        while (buffer.TryReceive<T>(out receivedItem))
        {
            receivedItems.Add(receivedItem);
        }
        return receivedItems;
    }
