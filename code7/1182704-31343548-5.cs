	{
	    System.Collections.IEnumerator e = ((System.Collections.IEnumerable)(new MyIntegers() as System.Collections.IEnumerable)).GetEnumerator();
	    try {
	        while (e.MoveNext()) {
	            System.Object v = (System.Object)(System.Object)e.Current;
	            embedded-statement
	        }
	    }
	    finally {
	        … // Dispose e
	    }
	}
