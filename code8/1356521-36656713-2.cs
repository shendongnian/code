    using System.Windows.Input;
    int vk = 0x55; // U
    Key key = KeyInterop.KeyFromVirtualKey(vk);
    
    if (Key.W == key)
        Console.WriteLine("True!");
