    public class Dog
    {
        private string _name;
        private int _age;
    	
    	public Dog(string name, int age)
    	{
    	    this._name = name;
    		this._age = age;
    	}
    	
    	public Dog setName(string name)
    	{
    		this._name = name;
    		
    		return this;
    	}
    	
    	public string getName()
    	{
    		return _name;
    	}
    	
    	public Dog setAge(int age)
    	{
    		this._age = age;
    		
    		return this;
    	}
    	
    	public int getAge()
    	{
    		return this._age;
    	}	
    }
    
    public class DogControl
    {
    	private Dog _dog;
    	
    	public DogControl(Dog dog)
    	{
    		_dog = dog;
    	}
    	
    	public void update()
        {
            try
            {
                Connection newcon = new Connection();
                newcon.connnew();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Connection.conect;
                cmd.CommandText = "UPDATE neelas.emp_login SET name=@name WHERE emp_id = @emp_id ";
                cmd.Parameters.AddWithValue("@emp_id", _dog.getAge());
                cmd.Parameters.AddWithValue("@name",_dog.getName());
                cmd.ExecuteNonQuery();
    
                MessageBox.Show("Data update in database");
                MessageBox.Show(GetName());
                // MessageBox.Show(conGetAge());
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }
    }
    
    private void update_Click(object sender, EventArgs e)
    {
        string Name = nameTxt.Text;
        int Age = Convert.ToInt32(AgeTxt.Text);
    
        Dog dg = new Dog(Name, Age);
    	DogControl control = new DogControl(dg);
        
    	dg.update();
    }
