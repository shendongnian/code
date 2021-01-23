	{
	    System.Collections.IEnumerator e = ((System.Collections.IEnumerable)(new MyIntegers() as System.Collections.IEnumerable)).GetEnumerator();
	    try {
	        while (e.MoveNext()) {
	            System.Object element = (System.Object)(System.Object)e.Current;
                Console.WriteLine(element);
	        }
	    }
	    finally {
            System.IDisposable d = e as System.IDisposable;
            if (d != null) d.Dispose();
	    }
	}
