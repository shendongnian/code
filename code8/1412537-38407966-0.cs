    public static int[] maxPart(int N, int[] A){
        int[] counters = new int[N];
        for(int i = 0; i < A.Length; i++){
            int X=A[i];
            if(X>=1 && X<=N){ // this encodes increment(X), with X=A[i] 
                 counters [X-1] = counters [X-1] + 1; //-1, because our index is 0-based  
             }
             if(X == N + 1 ){// this encodes setting all counters to the max value
                 int tmpMax = counters.Max ();
                 for(int h = 0; h < counters.Length; h++){
                        counters [h] = tmpMax;
                    }
                }
            }
        }
        return counters;
    }
