    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                IATA_PassengerConformanceIdentifyRQ localIataReq = new IATA_PassengerConformanceIdentifyRQ();
                XmlSerializer deserializer = new XmlSerializer(localIataReq.GetType());
                StreamReader reader = new StreamReader(FILENAME);
                XmlRootAttribute xRoot = new XmlRootAttribute();
                xRoot.ElementName = "IATA_PassengerConformanceIdentifyRQ";
                xRoot.IsNullable = false;
                localIataReq = (IATA_PassengerConformanceIdentifyRQ)deserializer.Deserialize(reader);
                reader.Close();
            }
        }
        [XmlRoot("IATA_PassengerConformanceIdentifyRQ")]
        public partial class IATA_PassengerConformanceIdentifyRQ
        {
            [XmlElement("Originator")]
            public Originator  originator { get; set;}
            [XmlElement("InvokingBusinessActivity")]
            public InvokingBusinessActivity invokingBusinessActivity { get; set; }
            [XmlElement("Passenger")]
            public Passenger passenger { get; set; }
        }
        [XmlRoot("Originator")]
        public partial class Originator
        {
            [XmlElement("Source")]
            public Source source { get; set;}
        }
        [XmlRoot("Source")]
        public class Source 
        {
            [XmlAttribute("AgentSine")]
            public string agentSine { get; set; }
            [XmlAttribute("PseudoCityCode")]
            public string pseudoCityCode { get; set; }
            [XmlAttribute("ISOCountry")]
            public string iSOCountry { get; set; }
            
            [XmlAttribute("ISOCurrency")]
            public string iSOCurrency { get; set; }
            
            [XmlAttribute("AgentDutyCode")]
            public string agentDutyCode { get; set; }
            
            [XmlAttribute("AirlineVendorID")]
            public string airlineVendorID { get; set; }
            
            [XmlAttribute("AirportCode")]
            public string airportCode { get; set; }
            
            [XmlAttribute("FirstDepartPoint")]
            public string firstDepartPoint { get; set; }
            
            [XmlAttribute("ERSP_UserID")]
            public string eRSP_UserID { get; set; }
            
            [XmlAttribute("TerminalID")]
            public string terminalID { get; set; }
            [XmlElement("RequestorID")]
            RequestorID requestorID { get; set; }
            [XmlElement("Position")]
            Position position { get; set; }
            [XmlElement("BookingChannel")]
            BookingChannel bookingChannel { get; set; }
        }
        [XmlRoot("RequestorID")]
        public class RequestorID
        {
            [XmlAttribute("MessagePassword")]
            public string messagePassword { get; set; }
            [XmlAttribute("URL")]
            public string url { get; set; }
            [XmlAttribute("Type")]
            public string _type { get; set; }
            [XmlAttribute("Instance")]
            public string instance { get; set; }
            [XmlAttribute("ID")]
            public string id { get; set; }
            [XmlAttribute("ID_Context")]
            public string id_Context { get; set; }
            
        }
        [XmlRoot("Position")]
        public partial class Position
        {
            [XmlAttribute("Latitude")]
            public string latitude { get; set; }
            [XmlAttribute("Longitude")]
            public string longitude { get; set; }
            [XmlAttribute("Altitude")]
            public string altitude { get; set; }
            [XmlAttribute("AltitudeUnitOfMeasureCode")]
            public string altitudeUnitOfMeasureCode { get; set; }
        }
        [XmlRoot("BookingChannel")]
        public class BookingChannel
        {
            [XmlAttribute("Type")]
            public string _type { get; set; }
            [XmlAttribute("Primary")]
            public Boolean primary { get; set; }
        }
        [XmlRoot("InvokingBusinessActivity")]
        public class InvokingBusinessActivity
        {
            [XmlAttribute("Code")]
            public string code { get; set; }
            [XmlText]
            public string value { get; set; }
        }
        [XmlRoot("Passenger")]
        public class Passenger
        {
            [XmlElement("GUID")]
            public Value guid { get; set; }
            [XmlElement("NativeID")]
            public Value nativeID { get; set; }
            [XmlElement("Name")]
            public Name  name { get; set; }
            [XmlElement("CustomerLoyalty")]
            public List<CustomerLoyalty> customerLoyalty { get; set; }
            [XmlElement("BoardingPass")]
            public BoardingPass boardingPass { get; set; }
            [XmlElement("Segment")]
            public Segment segment { get; set; }
        }
        public class Value
        {
            [XmlText]
            public string value { get; set; }
        }
        [XmlRoot("Name")]
        public class Name
        {
            [XmlAttribute("ShareSynchInd")]
            public string shareSynchInd { get; set; }
            [XmlAttribute("ShareMarketInd")]
            public string shareMarketInd { get; set; }
            [XmlAttribute("NameType")]
            public string NameType { get; set; }
            [XmlElement("NamePrefix")]
            public List<string> namePrefix { get; set; }
            [XmlElement("GivenName")]
            public List<string> givenName { get; set; }
            [XmlElement("MiddleName")]
            public List<string> middleName { get; set; }
            [XmlElement("SurnamePrefix")]
            public List<string> surnamePrefix { get; set; }
            [XmlElement("Surname")]
            public List<string> surname { get; set; }
            [XmlElement("NameSuffix")]
            public string nameSuffix { get; set; }
            [XmlElement("NameTitle")]
            public string nameTitle { get; set; }
        }
        [XmlRoot("CustomerLoyalty")]
        public class CustomerLoyalty
        {
            [XmlAttribute("ShareSynchInd")]
            public string shareSynchInd { get; set; }
            [XmlAttribute("ShareMarketInd")]
            public string shareMarketInd { get; set; }
            [XmlAttribute("ProgramID")]
            public string programID { get; set; }
            [XmlElement("MembershipID")]
            public string membershipID { get; set; }
            [XmlElement("TravelSector")]
            public string travelSector { get; set; }
            [XmlElement("LoyalLevel")]
            public string loyalLevel { get; set; }
            [XmlElement("SingleVendorInd")]
            public string singleVendorInd { get; set; }
            [XmlElement("SignupDate")]
            public DateTime  signupDate { get; set; }
            [XmlElement("EffectiveDate")]
            public DateTime effectiveDate { get; set; }
            [XmlElement("ExpireDate")]
            public DateTime expireDate { get; set; }
            [XmlElement("RPH")]
            public string rph { get; set; }
            [XmlElement("VendorCode")]
            public string vendorCode { get; set; }
        }
        [XmlRoot("BoardingPass")]
        public class BoardingPass
        {
            [XmlElement("ForIndividualAirlineUse")]
            public string forIndividualAirlineUse { get; set; }
            [XmlElement("DigitalSignature")]
            public DigitalSignature digitalSignature { get; set; }
        }
        [XmlRoot("DigitalSignature")]
        public class DigitalSignature
        {
            [XmlAttribute("Type")]
            public int _type { get; set; }
            [XmlText]
            public string value { get; set; }
        }
        [XmlRoot("Segment")]
        public class Segment
        {
            [XmlElement("PNR")]
            public PNR pnr { get; set; }
            [XmlElement("NativeID")]
            public string nativeID { get; set; }
            [XmlElement("Flight")]
            public Flight flight { get; set; }
            [XmlElement("DepartureAirport")]
            public Airport departureAirport { get; set; }
            [XmlElement("ArrivalAirport")]
            public Airport arrivalAirport { get; set; }
            [XmlElement("Cabin")]
            public string cabin { get; set; }
            [XmlElement("SeatNumber")]
            public string seatNumber { get; set; }
            [XmlElement("CheckInSequenceNumber")]
            public string checkInSequenceNumber { get; set; }
        }
        [XmlRoot("PNR")]
        public class PNR
        {
            [XmlAttribute("URL")]
            public string url { get; set; }
            [XmlAttribute("Type")]
            public string _type { get; set; }
            [XmlAttribute("Instance")]
            public string Instance { get; set; }
            [XmlAttribute("ID")]
            public string id { get; set; }
            [XmlAttribute("ID_Context")]
            public string id_Context { get; set; }
        }
        [XmlRoot("Flight")]
        public class Flight
        {
            [XmlElement("NativeID")]
            public string nativeID { get; set; }
            [XmlElement("OperatingCarrier")]
            public string operatingCarrier { get; set; }
            [XmlElement("FlightNumber")]
            public string flightNumber { get; set; }
            [XmlElement("OperationalSuffix")]
            public string operationalSuffix { get; set; }
            [XmlElement("MarketingCarrier")]
            public string marketingCarrier { get; set; }
            [XmlElement("ScheduledDateOfDeparture")]
            public DateTime scheduledDateOfDeparture { get; set; }
            [XmlElement("ScheduledTimeOfDeparture")]
            public DateTime scheduledTimeOfDeparture { get; set; }
            [XmlElement("ScheduledDateOfArrival")]
            public DateTime scheduledDateOfArrival { get; set; }
            [XmlElement("ScheduledTimeOfArrival")]
            public DateTime scheduledTimeOfArrival { get; set; }
        }
        public class Airport
        {
            [XmlElement("AirportCode")]
            public string airportCode { get; set; }
            [XmlElement("SourceIndicator")]
            public int sourceIndicator { get; set; }
        }
    }
    ​
