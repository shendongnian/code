    Queue<Byte[]> q = new Queue<Byte[]>();
    Byte[] block = new Byte[1];
    block[0] = 1;
    q.Enqueue(block);
    // Create a new array
    block = new Byte[1];
    block[0] = 2;
    q.Enqueue(block);
    // Create a new array
    block = new Byte[1];
    block[0] = 3;
    q.Enqueue(block);
    byte[] block1 = q.Dequeue();
    Console.WriteLine(block1[0]);
    block1 = q.Dequeue();
    Console.WriteLine(block1[0]);
    block1 = q.Dequeue();
    Console.WriteLine(block1[0]);
