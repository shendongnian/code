    public class MainActivity : Activity
        {
    
            public class MyItem
            {
                public string[]  options { get; set; }
                public int id { get; set; }
            }
            public class MyMultiAnswer
            {
                public int _QuestionId { get; set; }
            }
    
            private List<CheckBox> _chkList = new List<CheckBox>();
    
            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
    
                var _Item = new MyItem() { options =new string [] { "aaa", "bbb", "ccc" }, id=0 };
                var _MultiAnswer = new MyMultiAnswer() { _QuestionId = 0 };
    
                
    
                ScrollView _Scroll = new ScrollView(this);
                _Scroll.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
                LinearLayout _LScroll = new LinearLayout(this);
                _LScroll.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
                _LScroll.Orientation = Orientation.Vertical;
                _LScroll.SetGravity(GravityFlags.CenterHorizontal);
    
                TextView txView = new TextView(this);
    
                //_Scroll.AddView(_LScroll);
                Button _Send = new Button(this);
                _Send.Text = "test";
                _Send.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
    
                for (int i = 0; i < _Item.options.Length; i++)
                {
                    CheckBox _Options = new CheckBox(this);
                    _chkList.Add(_Options);
                    _Options.Text = _Item.options[i];
                    _Options.Id = i;
                    _Options.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
                    _LScroll.AddView(_Options);
                }
    
                _Send.Click += delegate
                {
                    _MultiAnswer._QuestionId = _Item.id;
                    string strChkIds = "";
    
                    foreach (var chk in _chkList.Where(c => c.Checked))
                    {
                        //_MultiAnswer._AnwserOptionIds.SetValue(_Options.Id + 1, _Options.Id);
                        //do something
                        strChkIds += " - " + chk.Id;
                    }
    
                    // or
    
                    for (int i = 0; i < _Item.options.Length; i++)
                    {
                        if (_chkList[i].Checked == true)
                        {
                            //_MultiAnswer._AnwserOptionIds.SetValue(i + 1, i);
                            //do something
                        }
                    }
    
                    //output = JsonConvert.SerializeObject(_MultiAnswer);
                    //SendJson(_Url, DataCache._Login, output);
    
                    //SetLayout(layout, btn);
                    txView.Text = "selected ids " + strChkIds;
                };
    
                _Scroll.AddView(_LScroll);
                _LScroll.AddView(_Send);
                _LScroll.AddView(txView);
    
                // Set our view from the "main" layout resource
                SetContentView(_Scroll);
    
            }
        }
