    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication102
    {
        class Program
        {
            enum State
            {
                FIND_HEADINGBEGIN,
                HEADINGBEGIN,
                EMPLOYEE,
                FIND_GROUPBEGIN,
                GROUP
            }
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                List<Employee> employees = ParseXml(FILENAME);
            }
            static List<Employee> ParseXml(string filename)
            {
                string employeePattern = @"Employee:\s*(?'employee'\d*)\s+Name:\s*(?'name'[^\s]*)\s*Base:\s+(?'base'[^\s]*)\s*Eqpt:\s+(?'eqpt'[^\s]*)\s+Pos:\s+(?'pos'[^\s]*)";
                List<Employee> employees = new List<Employee>();
                Employee newEmployee = null;
                List<int> assmentColumnWidths = new List<int>() {7, 7, 14, 7, 7, 8, 16, 8, 8};
                int lineNo = 0;
                State state = State.FIND_HEADINGBEGIN;
                XDocument doc = XDocument.Load(FILENAME);
                foreach (XElement xLine in doc.Descendants("Line"))
                {
                    string line = ((string)xLine).Trim();
                    if (line.Length > 0)
                    {
                        switch (state)
                        {
                            case State.FIND_HEADINGBEGIN:
                                if (line.StartsWith("#HEADINGBEGIN#"))
                                {
                                    state = State.HEADINGBEGIN;
                                    lineNo = 0;
                                }
                                break;
                            case State.HEADINGBEGIN:
                                if (line.StartsWith("#HEADINGEND#"))
                                {
                                    state = State.EMPLOYEE;
                                }
                                else
                                {
                                    if (lineNo++ == 0)
                                    {
                                        newEmployee = new Employee();
                                        employees.Add(newEmployee);
                                        Match expr = Regex.Match(line, employeePattern);
                                        newEmployee.id = expr.Groups["employee"].Value;
                                        newEmployee.name = expr.Groups["name"].Value;
                                        newEmployee._base = expr.Groups["base"].Value;
                                        newEmployee.eqpt = expr.Groups["eqpt"].Value;
                                        newEmployee.pos = expr.Groups["pos"].Value;
                                        newEmployee.eqpt = expr.Groups["eqpt"].Value;
                                    }
                                }
                                break;
                            case State.EMPLOYEE:
                                if (line.StartsWith("#GROUPNOBREAK#"))
                                {
                                    state = State.FIND_GROUPBEGIN;
                                    lineNo = 0;
                                }
                                else
                                {
                                    List<string> assignmentData = GetFixedWidth(line, assmentColumnWidths);
                                    Assignment assignment = new Assignment();
                                    if (newEmployee.assignments == null) newEmployee.assignments = new List<Assignment>();
                                    newEmployee.assignments.Add(assignment);
                                    assignment.date = assignmentData[0];
                                    assignment.name = assignmentData[1];
                                    assignment.onDuty = assignmentData[2];
                                    assignment.offDuty = assignmentData[3];
                                    assignment.tafb = assignmentData[4];
                                    assignment.dailyBlock = assignmentData[5];
                                    assignment.dailyCredit = assignmentData[6];
                                    assignment.tripGuarantee = assignmentData[7];
                                    assignment.jrMan = assignmentData[8];
                                }
                                break;
                            case State.FIND_GROUPBEGIN:
                                if (line.StartsWith("#GROUPBEGIN#"))
                                {
                                    state = State.GROUP;
                                    Total total = new Total();
                                    newEmployee.total = new Total();
                                }
                                break;
                            case State.GROUP:
                                if (line.StartsWith("#GROUPEND#"))
                                {
                                    state = State.FIND_HEADINGBEGIN;
                                }
                                else
                                {
                                    string[] splitLine = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                    switch (++lineNo)
                                    {
                                        case 1 :
                                            newEmployee.total.taxable = splitLine[2];
                                            break;
                                        case 2:
                                            newEmployee.total.nonTaxable = splitLine[2];
                                            break;
                                        case 3:
                                            newEmployee.total.total = splitLine[2];
                                            break;
                                    }
                                }
                                break;
                        }
                    }
                }
                return employees;
            }
            static List<string> GetFixedWidth(string input, List<int> columns)
            {
                int index = 0;
                List<string> output = new List<string>();
                for (int startPos = 0; (startPos < input.Length) && (index < columns.Count); startPos += columns[index])
                {
                    if (startPos + columns[index] <= input.Length)
                    {
                        output.Add(input.Substring(startPos, columns[index++]).Trim());
                    }
                    else
                    {
                        output.Add(input.Substring(startPos).Trim());
                    }
                }
                return output;
            }
        }
        public class Employee
        {
            public string id { get; set; }
            public string name { get; set; }
            public string _base { get; set; }
            public string eqpt { get; set; }
            public string pos { get; set; }
            public List<Assignment> assignments { get; set; }
            public Total total { get; set; }
        }
        public class Assignment
        {
            public string date { get; set; }
            public string name { get; set; }
            public string onDuty { get; set; }
            public string offDuty { get; set; }
            public string tafb { get; set; }
            public string dailyBlock { get; set; }
            public string dailyCredit { get; set; }
            public string tripGuarantee { get; set; }
            public string jrMan { get; set; }
        }
        public class Total
        {
            public string taxable { get; set; }
            public string nonTaxable { get; set; }
            public string total { get; set; }
        }
    }
