    private Button Button1;
	
	@Override
	public void onCreate(Bundle savedInstanceState)
	{		
		super.onCreate(savedInstanceState);
        Button1.setOnTouchListener(new OnTouchListener()
        {
            @Override
            public boolean onTouch(View v, MotionEvent event)
            {
                if (event.getAction() == MotionEvent.ACTION_DOWN)
                {
                	//do stuff
                }
                else if (event.getAction() == MotionEvent.ACTION_UP)
                {
                	// do stuff
                }
                return false;
            }
        });
    }
