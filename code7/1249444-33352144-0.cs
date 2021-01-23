I would suggest looking into the [IComparer&lt;T&gt;][1] interface. You can make a version of your MergeSort algorithm that takes an IComparer&lt;T&gt; which can be used to compare the objects for sorting. It would probably give you similar functionality to what you are used to.
You could do this in addition to defining a version of MergeSort that restricts the type to IComparable. This way, between both versions of the function, you can handle objects that implement the interface already and also allow your users to provide a comparison for objects that don't implement it.
You could put the MergeSort in as an [Extension Method][2] on the IList&lt;T&gt; interface as such.
    public static class MergeSortExtension
    {
        public static IList<T> MergeSort<T>(this IList<T> list) where T : IComparable<T>
        {
            return list.MergeSort(Comparer<T>.Default);
        }
        public static IList<T> MergeSort<T>(this IList<T> list, IComparer<T> comparer)
        {
            // Sort code.  
        }
    }
