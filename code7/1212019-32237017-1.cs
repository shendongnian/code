    // 1
    interface I<T, S, R>
    {
      S M(T t, R r);
      T N();
    }
    // 2
    interface I<T, out S, R>
    {
      S M(T t, R r);
      T N();
    }
    // 3
    interface I<T, S, in R>
    {
      S M(T t, R r);
      T N();
    }
    // 4
    interface I<T, out S, in R>
    {
      S M(T t, R r);
      T N();
    }
