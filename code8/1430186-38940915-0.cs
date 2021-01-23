    interface I1<T>
    	{
    		void Some ();
    	}
    
    	class C1<T> : I1<T> where T:class{ 
    		public void M1() {}
    
    		public void Some()
    		{
    		}
    	}
    	class C2<T> : I1<T> where T:class{
    		public void M2() {}
    		public void Some()
    		{
    		}
    	}
    	class C3<T> where T:class {
    		void M3(I1<T> x){
    			if (x is C1<T>) (x as C1<T>).M1();
    			else if (x is C2<T>) (x as C2<T>).M2();
    		}
    
    		public void Some()
    		{
    		}
    	}
