    using System.Collections.Concurrent;
    
    ConcurrentDictionary<string, SymbolOrderBook> books = new ConcurrentDictionary<string, SymbolOrderBook>();
    SymbolOrderBook book = new SymbolOrderBook(symbol);
    books.GetOrAdd(symbol, book);
