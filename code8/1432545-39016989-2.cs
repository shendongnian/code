     public class FragmentClass1 : Fragment
     {
         public override void OnCreate(Bundle savedInstanceState)
         {
             base.OnCreate(savedInstanceState);
         }
         public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
         {
             View view = inflater.Inflate(Resource.Layout.Fragment1, container, false);
             //THIS IS FOR IF YOU NEED ACCESO TO CONTEXT,
             // OR MAINACTIVITY PROPERTIES OR FUNCTIONS
             MainActivity myActivity = (MainActivity )this.Activity;
             return view;
         }
