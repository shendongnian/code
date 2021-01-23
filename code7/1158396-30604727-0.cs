    //using System;
    //using Sytem.Collections.Generic
    public class UndoableObject<T>
    {
        List<T> _list = new List<T>();
        string _name;
        int _step = 0;
        public UndoableObject(T source, string name)
        {
            _list.Clear();
            _list = new List<T>();
            _list.Add(source);
            _name = name;
            _step = 0;
        }
        public string GetName
        {
            get { return _name; }
        }
        public void Record(T item)
        {
            _list.Add(item);
            _step++;
        }
        public T Undo()
        {
            _step--;
            if (_step >= 0)
            {
                return _list[_step];
            }
            else
            {
                _step = 0;
                return _list[_step];
            }
        }
        public T Redo()
        {
            _step++;
            if (_step < _list.Count)
            {
                return _list[_step];
            }
            else
            {
                _step = _list.Count - 1;
                return _list[_step];
            }
        }
    }
