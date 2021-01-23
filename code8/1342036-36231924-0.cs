    using System.Threading.Tasks;
    ...
    
    Task.Factory.StartNew(() => Processfiles("TCS"));
    Task.Factory.StartNew(() => Zipfiles("RCS"));
    Task.Factory.StartNew(() => Leveragefiles("CTS"));
    Task.WaitAll();//to make sure all the task is complete
     Downloadfiles();
