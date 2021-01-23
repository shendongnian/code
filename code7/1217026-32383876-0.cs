    private static Queue<Action> listOfMethods = new Queue<Action>();
    listOfMethods.Enqueue(method1);
    listOfMethods.Enqueue(method2);
    listOfMethods.Enqueue(method3);   
    private void buttonTest_Click(object sender, EventArgs e) {
        if (listOfMethods.Count > 0) {
            listOfMethods.Dequeue().Invoke();
        }
    }
