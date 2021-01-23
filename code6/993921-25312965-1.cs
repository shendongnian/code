    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace listadd
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Original GetSchedule:");
                MyListData mld = GetSchedule();
                for (int i = 0; i < mld.HeaderItems.Count; i++)
                {
                    Console.WriteLine(string.Format("HeaderItem: {0}, MatrixItem: {1}", mld.HeaderItems[i].strHeadName, mld.MatrixItems[i].nHRJobID));
                }
    
                Console.WriteLine();
    
                Console.WriteLine("Tuple GetSchedule:");
                var list = GetScheduleCombined();
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine(string.Format("HeaderItem: {0}, MatrixItem: {1}", list[i].Item1.strHeadName, list[i].Item2.nHRJobID));
                }
                Console.WriteLine();
                Console.WriteLine("combined GetSchedule:");
                var clist = GetScheduleCombined2();
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine(string.Format("HeaderItem: {0}, MatrixItem: {1}", clist[i].hdrItm.strHeadName, clist[i].mtxItm.nHRJobID));
                }
                Console.ReadKey();
                
            }
            
            public static List<Tuple<HeaderItem, MatrixItem>> GetScheduleCombined()
            {
                List<Tuple<HeaderItem, MatrixItem>> list = new List<Tuple<HeaderItem, MatrixItem>>();
                for (int x = 0; x < 7; x++)
                {
                    var h = new HeaderItem();
                    h.strHeadName = x;
                    var m = new MatrixItem();
                    m.nHRJobID = x;
                    list.Add(new Tuple<HeaderItem, MatrixItem>(h, m));
                }
                return list;
            }
 
            public class MyCombined
            {
                public MyCombined()
                {
                    hdrItm = new HeaderItem();
                    mtxItm = new MatrixItem();
                }
                public HeaderItem hdrItm { get; set; }
                public MatrixItem mtxItm { get; set; }
            }
            public static List<MyCombined> GetScheduleCombined2()
            {
                List<MyCombined> list = new List<MyCombined>();
                for (int x = 0; x < 7; x++)
                {
                    var item = new MyCombined();
                    item.hdrItm.strHeadName = x;
                    item.mtxItm.nHRJobID = x;
                    list.Add(item);
                }
                return list;
            }
    //----- begin original sample code from question -----
            public class MyListData
            {
                public List<HeaderItem> HeaderItems { get; set; }
                public List<MatrixItem> MatrixItems { get; set; }
            }
    
            public static MyListData GetSchedule()
            {
                MyListData objTab = new MyListData();
                objTab.HeaderItems = new List<HeaderItem>();
    
                //Header loop works perfectly
                for (int x = 0; x < 7; x++)
                {
                    HeaderItem objItem = new HeaderItem();
                    objItem.strHeadName = x;
                    objTab.HeaderItems.Add(objItem);
                }
    
                objTab.MatrixItems = new List<MatrixItem>();
                for (int x = 0; x < 7; x++)
                {
                    MatrixItem objItem = new MatrixItem();
                    objItem.nHRJobID = x;
                    objTab.MatrixItems.Add(objItem);
                }
    
                //Only adds the last one Need ALL
    
                return objTab;
    
            }
    // ---- End original sample code ----
        }
    }
