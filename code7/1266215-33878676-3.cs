    using System;
    using System.Collections.Generic;
    class Program
    {
        interface IPosition
        {
            string Title { get; }
            bool RequestVacation();
        }
        class Manager : IPosition
        {
             string IPosition.Title
            {
                get { return "Manager"; }
            }
            bool IPosition.RequestVacation()
            {
                return true;
            }
        }
        class Clerk : IPosition
        {
            int m_VacationDaysRemaining = 1;
            string IPosition.Title
            {
                get { return "Clerk"; }
            }
            bool IPosition.RequestVacation()
            {
                if (m_VacationDaysRemaining <= 0)
                {
                    return false;
                }
                else
                {
                    m_VacationDaysRemaining--;
                    return true;
                }
            }
        }
        class Programmer : IPosition
        {
            string IPosition.Title
            {
                get { return "Programmer"; }
            }
            bool IPosition.RequestVacation()
            {
                return false;
            }
        }
        static class Factory
        {
            public static IPosition Create<T>() where T : IPosition, new ()
            {
                return new T();
            }
        }
        static void Main(string[] args)
        {
            List<IPosition> positions = new List<IPosition>(3);
            positions.Add(Factory.Create<Manager>());
            positions.Add(Factory.Create<Clerk>());
            positions.Add(Factory.Create<Programmer>());
            foreach (IPosition p in positions) { Console.WriteLine(p.Title);  }
            Console.WriteLine();
            Random rnd = new Random(0);
            for (int i = 0; i < 10; i++)
            {
                int index = rnd.Next(3);
                Console.WriteLine("Title: {0}, Request Granted: {1}", positions[index].Title, positions[index].RequestVacation());
            }
            Console.ReadLine();
        }
    }
